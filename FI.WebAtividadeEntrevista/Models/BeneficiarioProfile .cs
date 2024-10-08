﻿using AutoMapper;
using FI.AtividadeEntrevista.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAtividadeEntrevista.Models
{
    public class BeneficiarioProfile : Profile
    {
        public BeneficiarioProfile()
        {
            CreateMap<BeneficiarioModel, Beneficiario>();
            CreateMap<Beneficiario, BeneficiarioModel>();
        }
    }

}