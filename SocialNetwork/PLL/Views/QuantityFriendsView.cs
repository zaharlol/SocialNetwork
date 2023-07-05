using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class QuantityFriendsView
    {
        public void Show(IEnumerable<Friend> addFriend)
        {
            Console.WriteLine("Список друзей");

            if (addFriend.Count() == 0)
            {
                Console.WriteLine("Друзей нет");
                return;
            }

            addFriend.ToList().ForEach(m =>
            {
                Console.WriteLine("Друзья: {0}", m.FriendId);
            });
        }
    }
}
