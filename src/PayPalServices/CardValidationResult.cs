namespace PayPalServices
{
    public enum CardValidationResult
    {
        Valid,
        Expired,
        InvalidCardNumber,
        MissingCvv2Code
    }
}