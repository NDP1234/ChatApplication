using dataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataModels.ViewModels
{
    public class ChatViewModel
    {
        //public int Userid { get; set; }
        public string StrForFirstUser { get; set; }
        public byte[] Userid { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public class CommonUserModel
        {
            public byte[] Id { get; set; }

            public byte[] UserId { get; set; }

            public string Sms { get; set; } = null!;

            public bool IsDelete { get; set; }

            public byte[]? CreatorId { get; set; }

            public byte[]? ModificationId { get; set; }

            public byte[]? DeletorId { get; set; }

            public DateTime? ModificationTime { get; set; }

            public DateTime? CreationTime { get; set; }
        }

        public List<CommonUserModel> commonUserModels { get; set; } = new List<CommonUserModel>();
    }
}
