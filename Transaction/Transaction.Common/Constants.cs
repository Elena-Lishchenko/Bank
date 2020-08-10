namespace Transaction.Common
{
	public static class Constants
	{
		public static class AccountTypeNames
		{
			public const string LegalEntity = "Legal entity";
			public const string Individual = "Individual";
			public const string NonResident = "NonResident";
		}

		public static class BankTransactionTypeNames
		{
			public const string Internal = "Internal";
			public const string External = "External";
		}

		public static class TransactionActionDescriptions
		{
			public const string Sms = "Отправить смс сообщение";
			public const string SendPaymentDocuments = "Отправить платежные документы";
			public const string SendEnglishPaymentDocuments = "Отправить платежные документы на английском языке";
			public const string SendDataToTax = "Отправить данные транзакции в налоговую инспекцию";
			public const string SendDataToPartner = "Отправить данные транзакции в банк партнер";
			public const string CreateModal = "Вывести окно с подтверждением операции";
		}

		public static class BankNames
		{
			public const string Sberbank = "Сбербанк";
			public const string Vtb = "Втб";
			public const string Alfabank = "Альфабанк";
		}
	}
}
