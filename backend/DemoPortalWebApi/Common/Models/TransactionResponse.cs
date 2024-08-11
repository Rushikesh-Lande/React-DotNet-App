using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Common.Models
{
    [BsonIgnoreExtraElements]
    public class TransactionResponse
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("secId")]
        public string SecId { get; set; }

        [BsonElement("request_time")]
        public DateTime? RequestTime { get; set; }

        [BsonElement("card_name")]
        public string CardName { get; set; }

        [BsonElement("card_code")]
        public string CardCode { get; set; }

        [BsonElement("terminal_id")]
        public string TerminalId { get; set; }

        [BsonElement("merchant_code")]
        public string MerchantCode { get; set; }

        [BsonElement("stan")]
        public string Stan { get; set; }

        [BsonElement("transaction_version")]
        public string TransactionVersion { get; set; }

        [BsonElement("rrn")]
        public string Rrn { get; set; }

        [BsonElement("card_scheme")]
        public string CardScheme { get; set; }

        [BsonElement("transaction_type")]
        public string TransactionType { get; set; }

        [BsonElement("card_no")]
        public string CardNo { get; set; }

        [BsonElement("expiry_date")]
        public string ExpiryDate { get; set; }

        [BsonElement("pin_or_sign")]
        public string PinOrSign { get; set; }

        [BsonElement("auth_code")]
        public string AuthCode { get; set; }

        [BsonElement("response_time")]
        public DateTime ResponseTime { get; set; }

        [BsonElement("card_mode")]
        public string CardMode { get; set; }

        [BsonElement("response_code")]
        public string ResponseCode { get; set; }

        [BsonElement("aid")]
        public string Aid { get; set; }

        [BsonElement("tvr")]
        public string Tvr { get; set; }

        [BsonElement("tsi")]
        public string Tsi { get; set; }

        [BsonElement("crypt_data")]
        public string CryptData { get; set; }

        [BsonElement("cvm")]
        public string Cvm { get; set; }

        [BsonElement("app_cryptogram")]
        public string AppCryptogram { get; set; }

        [BsonElement("bank_id")]
        public string BankId { get; set; }

        [BsonElement("ter_id")]
        public string TerId { get; set; }

        [BsonElement("tr_sl_no")]
        public string TrSlNo { get; set; }

        [BsonElement("scheme_name")]
        public string SchemeName { get; set; }

        [BsonElement("function_code")]
        public string FunctionCode { get; set; }

        [BsonElement("reason_code")]
        public string ReasonCode { get; set; }

        [BsonElement("transaction_amount")]
        public string TransactionAmount { get; set; }

        [BsonElement("systemStatusCode")]
        public string SystemStatusCode { get; set; }

        [BsonElement("mti")]
        public string Mti { get; set; }

        [BsonElement("processingCode")]
        public string ProcessingCode { get; set; }

        [BsonElement("trans_type")]
        public string TransType { get; set; }

        [BsonElement("card_scheme_name")]
        public string CardSchemeName { get; set; }

        [BsonElement("currency")]
        public string Currency { get; set; }

        [BsonElement("trans_response_code")]
        public string TransResponseCode { get; set; }

        [BsonElement("version")]
        public string Version { get; set; }

        [BsonElement("_class")]
        public string Class { get; set; }

        [BsonElement("date")]
        public string Date { get; set; }
        public string Merchant_code { get; set; }
    }
}
