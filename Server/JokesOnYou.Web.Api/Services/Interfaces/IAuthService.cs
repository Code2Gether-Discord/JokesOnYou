﻿using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<User> Login(UserLoginDTO userLoginDTO);
        public User Register(UserRegisterDTO userRegisterDTO);
    }
}