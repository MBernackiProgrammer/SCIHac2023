namespace Hackathon
{
    public enum EReturnedInfo
    {
        /// <summary>
        /// Zwraca błąd servera
        /// </summary>
        ServerError,

        /// <summary>
        /// Zadanie wykonane pomyślnie
        /// </summary>
        Success,

        /// <summary>
        /// Nieznany błąd
        /// </summary>
        UknowError,

        NoDatabaseConnection,

        None,
        NoInternet,
        NoEditRights,
        NotFiled,
        PermissionDenied,
    }

    public class OperationStatusx
    {
        public OperationStatusx() { }
        public OperationStatusx(string ErrorMessage, EReturnedInfo ReturnedInfo)
        {
            this.ErrorMessage = ErrorMessage;
            this.ReturnedInfo = ReturnedInfo;
        }

        public OperationStatusx(EReturnedInfo ReturnedInfo)
        {
            this.ReturnedInfo = ReturnedInfo;
        }
        public EReturnedInfo ReturnedInfo = EReturnedInfo.None;
        public string ErrorMessage { get; set; }
    }
}
