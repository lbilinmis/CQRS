﻿namespace CQRS.API.QueryCommand.Results
{
    public class GetStudentsQueryResult
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
