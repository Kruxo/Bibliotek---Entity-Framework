﻿namespace Labb_2.DTO;

public class AuthoredBooks
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<int> BookIds { get; set; }
}
