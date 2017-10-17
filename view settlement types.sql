create view dbo.SettlementTypes as 
select 1 as Type, 0.10 as DownpaymentPct,24 as MaxNoOfInstallments, 0.041  as Interest
union
select 2 as Type, 0.20 as DownpaymentPct,24 as MaxNoOfInstallments, 0.039 as Interest
union 
select 3 as Type, 0.30 as DownpaymentPct,36 as MaxNoOfInstallments, 0.036 as Interest
union 
select 4 as Type, 0.40 as DownpaymentPct,36 as MaxNoOfInstallments, 0.032 as Interest
union 
select 5 as Type, 0.50 as DownpaymentPct,48 as MaxNoOfInstallments, 0.026 as Interest


