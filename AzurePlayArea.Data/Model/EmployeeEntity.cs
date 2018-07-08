﻿using Microsoft.WindowsAzure.Storage.Table;

namespace AzurePlayArea.Data.Model
{
    public class EmployeeEntity : TableEntity
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int Gender { get; set; }
    }
}
