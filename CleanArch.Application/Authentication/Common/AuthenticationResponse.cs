﻿using CleanArch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Authentication.Common
{
    public record AuthenticationResponse(string firstname, string lastname, string Token);
}
