﻿using System;
using System.Collections.Generic;
using System.Text;
using ModelLayer;
using RepositoryLayer.Entity;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRespository
    {
        public UserEntity Register(RegisterModel model);
    }
}