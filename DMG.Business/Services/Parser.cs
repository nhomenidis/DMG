using System;
using System.Collections.Generic;
using System.Text;
using DMG.Business.Mappers;
using DMG.DatabaseContext.Repositories;
using DMG.Models;
using FileHelpers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DMG.Business.Services
{
    public interface IParser
    {
        IEnumerable<User> ParseFile();
    }

    public class Parser : IParser
    {
        private readonly IMapper<ParseModel, User> _parseModelMapper;
        private readonly IUserRepository _userRepository;
        private readonly IBillRepository _billRepository;
        //private readonly FileHelperEngine<ParseModel> _parseEngine; (how to declare this to DI container?)

        public Parser(
            IMapper<ParseModel,User> parseModelMapper, 
            IUserRepository userRepository, IBillRepository billRepository
            )
        {
            _parseModelMapper = parseModelMapper;
            _userRepository = userRepository;
            _billRepository = billRepository;
            // _parseEngine = parseEngine;
        }

       public IEnumerable<User> ParseFile()
        {
            var parseEngine = new FileHelperEngine<ParseModel>();
            var result = parseEngine.ReadFile(@"C:\Users\nhome\Desktop\CitizenDebts_100_3.txt");
            
            var users = _parseModelMapper.Map(result);
            return users;
        }
    }
}

