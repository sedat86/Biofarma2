﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BiofarmaDemo4.Models.Demo4
{
    public class User
    {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("email")]
            public string Email { get; set; }

            [JsonPropertyName("gender")]
            public string Gender { get; set; }

            [JsonPropertyName("status")]
            public string Status { get; set; }
        
    }
}
