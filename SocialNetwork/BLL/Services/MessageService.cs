using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.BLL.Services
{
    public class MessageService
    {
        IUserRepository userRepository;
        IMessageRepository messageRepository;
        public MessageService()
        {
            userRepository = new UserRepository();
            messageRepository = new MessageRepository();
        }
        public IEnumerable<Message> GetIncomingMessagesByUserId(int recipientId)
        {
            var messages = new List<Message>();

            messageRepository.FindByRecipientId(recipientId).ToList().ForEach(m =>
            {
                var senderUserEntity = userRepository.FindById(m.sender_id);
                var recipientUserEntity = userRepository.FindById(m.recipient_id);

                messages.Add(new Message(m.id, m.content, senderUserEntity.email, recipientUserEntity.email));
            });

            return messages;
        }

        public IEnumerable<Message> GetOutcomingMessagesByUserId(int senderId)
        {
            var messages = new List<Message>();

            messageRepository.FindBySenderId(senderId).ToList().ForEach(m =>
            {
                var senderUserEntity = userRepository.FindById(m.sender_id);
                var recipientUserEntity = userRepository.FindById(m.recipient_id);

                messages.Add(new Message(m.id, m.content, senderUserEntity.email, recipientUserEntity.email));
            });

            return messages;
        }
        public void Send(MessageSending messageSending)
        {
            if (String.IsNullOrEmpty(messageSending.Content)) throw new ArgumentNullException();

            if (messageSending.Content.Length > 5000) throw new ArgumentOutOfRangeException();

            var findUser = this.userRepository.FindByEmail(messageSending.RecipientEmail);
            if (findUser is null) throw new UserNotFoundException();

            var message = new MessageEntity
            {
                content = messageSending.Content,
                sender_id = messageSending.SenderId,
                recipient_id = findUser.id
            };

            if (this.messageRepository.Create(message) == 0) 
                throw new Exception();
            
        }
    }
}
