using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Structural.Proxy.implementation.datacontract
{
    /*
     * Same as record, but using a class instead of a record. This is to demonstrate the difference between the two.
    public class UserSession
    {
    public string Username { get; }
    public UserRole Role { get; } // Changed from string to UserRole enum

    public UserSession(string username, UserRole role)
    {
        Username = username;
        Role = role;
    }
    }
    */
    internal record UserSession(string Username, UserRole Role);
}
