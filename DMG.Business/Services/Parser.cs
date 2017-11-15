using System;
using System.Collections.Generic;
using System.Text;
using DMG.Business.Mappers;
using DMG.DatabaseContext.Repositories;
using DMG.Models;
using FileHelpers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using DMG.Business.Dtos;

namespace DMG.Business.Services
{
    public interface IParser
    {
        Task ParseFile(string filePath, int batchSize);
    }

    public class Parser : IParser
    {
        private readonly IMapper<IEnumerable<ParseModel>, User> _parseModelMapper;
        private readonly IUserRepository _userRepository;

        public Parser(
            IMapper<IEnumerable<ParseModel>, User> parseModelMapper,
            IUserRepository userRepository, IBillRepository billRepository
            )
        {
            _parseModelMapper = parseModelMapper;
            _userRepository = userRepository;
        }

        public async Task ParseFile(string filePath, int batchSize)
        {
            string sortedFilePath = filePath + "-sorted";
            var sorter = new BigFileSorter<ParseModel>(5 * 1024 * 1024); // 5 Mb blocks

            sorter.Sort(filePath, sortedFilePath);

            var parseEngine = new FileHelperAsyncEngine<ParseModel>();
            using (parseEngine.BeginReadFile(sortedFilePath, batchSize * 5))
            {
                string currentVat = null;
                var parseGroup = new List<ParseModel>();
                var userBatch = new List<User>(batchSize);
                foreach (var parseModel in parseEngine) //foreach row in file
                {
                    currentVat = currentVat ?? parseModel.VAT;

                    if (parseModel.VAT == currentVat)
                    {
                        parseGroup.Add(parseModel);
                    }
                    else
                    {
                        var user = _parseModelMapper.Map(parseGroup);
                        userBatch.Add(user);

                        if (userBatch.Count == batchSize)
                        {
                            await SaveUserBatch(userBatch);
                            userBatch.Clear();
                        }

                        parseGroup.Clear();
                        currentVat = parseModel.VAT;
                        parseGroup.Add(parseModel);
                    }
                }
            }
        }

        private async Task SaveUserBatch(IEnumerable<User> users)
        {
            await _userRepository.InsertMany(users);
        }
    }
}

