namespace Validation.Validation
{
    public class ValidatorResult
    {
        public bool successful { get; set; }
        public string failure_message { get; set; }

        public bool Equals(ValidatorResult other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.successful.Equals(successful) && Equals(other.failure_message, failure_message);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ValidatorResult)) return false;
            return Equals((ValidatorResult) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (successful.GetHashCode()*397) ^ (failure_message != null ? failure_message.GetHashCode() : 0);
            }
        }
    }
}