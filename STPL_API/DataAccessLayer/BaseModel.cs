﻿namespace STPL_API.DataAccessLayer
{
    public class BaseModel
    {

        private string _EventLogMessage = "";

        public void SetEventLogMessage(string EventLogMessage)
        {
            _EventLogMessage = EventLogMessage;
        }

        public string GetEventLogMessage()
        {

            return _EventLogMessage;
        }

        public override String ToString()
        {
            return null;
        }
    }
}

