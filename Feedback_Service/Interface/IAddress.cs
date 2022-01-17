using Feedback_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedback_Service.Interface
{
    public interface IAddress : IDisposable
    {
        public void AddAddress(Address address);
        public Address GetAddressByID(int? id);
        public void DeleteAddressByID(int? id);
        void UpdateAddress(Address address);
        bool Any(int? Id);
    }
}
