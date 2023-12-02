using Hackathon.dbContext;
using Hackathon.dbContext.user;
using Hackathon.Helper;
using Hackathon.dbContext.classification;
using Hackathon.dbContext.chat;
using System.Linq;
using Hackathon.dbContext.user_files;
using Microsoft.AspNetCore.Mvc;
using Hackathon.Helper.OperationStatus;

namespace Hackathon.Helper
{
    public class Helpers
    {
        public static Int64 Login(string Login, string Password)
        {
            using(var dbContext = new Data_context())
            {
                var user = dbContext.user_data.Where(e=>e.login.Equals(Login) && e.password.Equals(Password)).FirstOrDefault();
                if(user == null)
                {
                    return -1;
                }

                return user.id;
            }
        }
        public static OperationStatusx CreateAccount(string Login, string Password, string EMail, string DisplayUserName)
        {
            using(var dbContext = new Data_context())
            {
                var NewEntity = new user_data
                {
                    login = Login,
                    password = Password,
                    email = EMail,
                    user_name = DisplayUserName
                };
                dbContext.user_data.Add(NewEntity);
                dbContext.SaveChanges();
                dbContext.Dispose();
            }
            return new OperationStatusx(EReturnedInfo.Success);
        }

        public static OperationStatusx UpdateAccount(Int64 UserID, string EMail, string DisplayUserName)
        {
            using (var dbContext = new Data_context())
            {
                var EntityToEdit = dbContext.user_data.Find(UserID);

                if (EntityToEdit == null)
                {
                    return new OperationStatusx("", EReturnedInfo.UknowError);
                }

                if(!string.IsNullOrEmpty(EMail))
                {
                    EntityToEdit.email = EMail;
                }

                if(!string.IsNullOrEmpty(DisplayUserName))
                {
                    EntityToEdit.user_name = DisplayUserName;
                }

                dbContext.Dispose();

                return new OperationStatusx(EReturnedInfo.Success);
            }
        }

        public static OperationStatusx DeleteAccount(Int64 UserID) 
        {
            using(var dbContext = new Data_context())
            {
                var EntityToRemove = new user_data
                {
                    id = UserID,
                };
                dbContext.user_data.Remove(EntityToRemove);
                dbContext.SaveChanges();
                dbContext.Dispose();

                return new OperationStatusx(EReturnedInfo.Success);
            }
        }

        public static OperationStatusx AddAnwser(Int64 ToUserID, Int64 QuestionId, string Value)
        {
            using(var dbContext = new Data_context())
            {
                var NewEntity = new user_answer
                {
                    to_question = QuestionId,
                    value = Value,
                    user_id = ToUserID
                };

                dbContext.user_answer.Add(NewEntity);
                dbContext.SaveChanges();
                dbContext.Dispose();

                return new OperationStatusx(EReturnedInfo.Success);
            }
        }

        public static OperationStatusx DeleteAnwser(Int64 UserID, Int64 ToQuestionID)
        {
            using(var dbContext = new Data_context())
            {
                var EntityToRemove = new user_answer
                {
                    user_id = UserID,
                    to_question = ToQuestionID
                };

                dbContext.user_answer.Remove(EntityToRemove);
                dbContext.SaveChanges();
                dbContext.Dispose();
                return new OperationStatusx(EReturnedInfo.Success);
            }
        }

        public static OperationStatusx EditAnwser(Int64 UserID, Int64 ToQuestionID, string NewValue)
        {
            using (var dbContext = new Data_context())
            {
                var EntityToFind = new user_answer
                {
                    user_id = UserID,
                    to_question = ToQuestionID,
                };
                var EntityToEdit = dbContext.user_answer.Find(EntityToFind);

                EntityToFind.value = NewValue;
                dbContext.SaveChanges();
                dbContext.Dispose();
                return new OperationStatusx(EReturnedInfo.Success);
            }
        }

        public static Int64 NextMatch(Int64 UserID)
        {
            using(var dbContext = new Data_context())
            {
                var UserFilters = dbContext.user_filters.Where(e => e.user_id.Equals(UserID)).FirstOrDefault(); //takie chce mieć user 

                var usersEX = dbContext.match_history.Where(e => e.user_id.Equals(UserID)).ToList(); // jego ex


                if (UserFilters == null)
                {
                    return -1;
                }

                var Filter = new user_filter_data
                {
                    
                    tv = UserFilters.tv,
                    sex = UserFilters.sex,
                    location = UserFilters.location,
                    
                };

                var x2 = dbContext.user_filter_data.Where(e => e.location.Equals(Filter.location) && e.tv.Equals(Filter.tv) && e.sex.Equals(Filter.sex)).ToList(); //matches

                foreach( var User in x2 )
                {
                    if(usersEX.Count == 0)
                    {
                        if (!User.user_id.Equals(UserID))
                        {
                            var newEX = new match_history
                            {
                                user_id = UserID,
                                match_user_id = User.user_id
                            };
                            dbContext.match_history.Add(newEX);
                            dbContext.SaveChanges();
                            dbContext.Dispose();

                            return User.user_id;

                        }
                        else
                        {
                            continue;
                        }
                    }
                    bool wasntEX = true;
                    foreach(var ex in usersEX)
                    {
                        if (User.user_id.Equals(ex.match_user_id) || User.user_id.Equals(UserID))
                        {
                            wasntEX = false;
                            break;

                        }
                            
                    }
                    
                    if( wasntEX)
                    {
                        var newEX = new match_history
                        {
                            user_id = UserID,
                            match_user_id = User.user_id
                        };
                        dbContext.match_history.Add(newEX);
                        dbContext.SaveChanges();
                        dbContext.Dispose();

                        return User.user_id;
                    }
                    

                }

                return -1;
            }
            
        }

        public static OperationStatusx SendRequest(Int64 ByUserID, Int64 ToUserID)
        {
            using(var dbContext = new Data_context())
            {
                var NewEntity = new match_data
                {
                    sent_at = DateTime.Now,
                    usr1 = ByUserID, 
                    usr2 = ToUserID,
                };
                dbContext.match_data.Add(NewEntity);
                dbContext.SaveChanges();
                dbContext.SaveChanges();
            }

            return new OperationStatusx(EReturnedInfo.Success);
        }

        public static OperationStatusx AcceptRequest(Int64 RequestID)
        {
            using( var dbContext = new Data_context())
            {
                var x = dbContext.match_data.Find(RequestID);
                x.accepted = true;
                dbContext.SaveChanges();
                dbContext.Dispose();
                return new OperationStatusx(EReturnedInfo.Success);
            }
        }

        public static OperationStatusx DeleteRequest(Int64 RequestID)
        {
            using (var dbContext = new Data_context())
            {
                var entityToRemove = new match_data
                {
                    id = RequestID
                };
                dbContext.match_data.Remove(entityToRemove);
                dbContext.SaveChanges();
                dbContext.Dispose();
                return new OperationStatusx(EReturnedInfo.Success);
            }
        }

        public static List<Int64> GetAllInvitations(Int64 UserID)
        {
            using(var dbContext = new Data_context())
            {
                var GotInvitation = dbContext.match_data.Where(e=>e.usr2 == UserID).ToList();
                List<Int64> InvitationsGot = new List<Int64>();

                foreach(var invitation in GotInvitation)
                {
                    if(!invitation.accepted)
                    {
                        InvitationsGot.Add(invitation.usr1);
                    }
                    
                }

                return InvitationsGot;
            }
        }

        //Zwraca chaty w których użytkownik bierze udział
        public static List<Int64> GetAllChats(Int64 UserID)
        {
            using (var dbContext = new Data_context())
            {
                var GotInvitation = dbContext.match_data.Where(e => e.usr2 == UserID).ToList();
                List<Int64> InvitationsGot = new List<Int64>();

                foreach (var invitation in GotInvitation)
                {
                    if (invitation.accepted)
                    {
                        InvitationsGot.Add(invitation.id);
                    }

                }

                return InvitationsGot;
            }
        }

        public static List<chat_messages> GetLastMesseges(Int64 ChatID)
        {
            using(var dbContext = new Data_context())
            {
                var x = dbContext.chat_messages.Where(e=> e.to_chat_id.Equals(ChatID)).Take(50).OrderBy(e=>e.by_id).ToList();
                if(x == null)
                {
                    return new List<chat_messages>();
                }

                return x.ToList();
            }
        }

        public static OperationStatusx RegestryNewFile(Int64 UserID, string Url)
        {
            using(var dbContext = new Data_context())
            {
                var NewEntity = new files
                {
                    stick_to_user = UserID,
                    url = Url
                };

                dbContext.files.Add(NewEntity);
                dbContext.SaveChanges();
                dbContext.Dispose();

                return new OperationStatusx(EReturnedInfo.Success);
            }
        }

        public static string GetFileUrl(Int64 FileID)
        {
            using( var dbContext = new Data_context())
            {
                var EntityFound = dbContext.files.Where(e => e.Equals(FileID)).ToList()[0];

                return EntityFound.url;
            }
        }


    }
}
