using System;

namespace Flare
{
   public class Message
   {
      public Message(string name, string message, string elementId, string className)
      {
         Name = name;
         TextMessage = message;
         ElementId = elementId;
         ClassName = className;
      }

      public String Name;
      public String TextMessage;
      public String ElementId;
      public string ClassName;
   }
}