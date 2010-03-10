using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Validation.Helpers;
using Validation.Mapping.ValidationBuilders.Failure;
using Validation.Validation.Failures;
using Validation.Validation.Validators;

namespace Validation.Mapping.ValidationBuilders.Strings
{
    public partial class StringValidationBuilder<T>
    {
        public IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> equal_to(string value)
        {
            var validator = new EqualsValidator<T, string>(expression, value);
            base.add_validator_with_not_wrapper_if_needed(validator);
            return new FailureValidationBuilder<T, IStringEntryValidationBuilder<T>>(validator, validators, ignore_validators, this);
        }

        public IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> equal_to(int value)
        {
            var validator = new EqualsValidator<T, int>(get_length_expression(), value);
            base.add_validator_with_not_wrapper_if_needed(validator);
            return new FailureValidationBuilder<T, IStringEntryValidationBuilder<T>>(validator, validators, ignore_validators, this);
        }

        public IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> greater_than(int value)
        {
            var validator = new GreaterThanValidator<T,int>(get_length_expression(), value);
            base.add_validator_with_not_wrapper_if_needed(validator);
            return new FailureValidationBuilder<T, IStringEntryValidationBuilder<T>>(validator, validators, ignore_validators, this);
        }

        public IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> greater_than_or_equal_to(int value)
        {
            var validator = new GreaterThanEqualToValidator<T,int>(get_length_expression(), value);
            base.add_validator_with_not_wrapper_if_needed(validator);
            return new FailureValidationBuilder<T, IStringEntryValidationBuilder<T>>(validator, validators, ignore_validators, this);
        }

        public IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> less_than(int value)
        {
            var validator = new LessThanValidator<T, int>(get_length_expression(), value);
            base.add_validator_with_not_wrapper_if_needed(validator);
            return new FailureValidationBuilder<T, IStringEntryValidationBuilder<T>>(validator, validators, ignore_validators, this);
        }

        public IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> less_than_or_equal_to(int value)
        {
            var validator = new LessThanEqualToValidator<T, int>(get_length_expression(), value);
            base.add_validator_with_not_wrapper_if_needed(validator);
            return new FailureValidationBuilder<T, IStringEntryValidationBuilder<T>>(validator, validators, ignore_validators, this);
        }

        public IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> not_null()
        {
            var validator = new NullValidator<T,string>(expression);
            base.add_validator_with_not_wrapper_if_needed(validator);
            return new FailureValidationBuilder<T, IStringEntryValidationBuilder<T>>(validator, validators, ignore_validators, this);
        }

        public IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> not_empty()
        {
            var validator = new NotEmptyValidator<T, string>(expression);
            base.add_validator_with_not_wrapper_if_needed(validator);
            return new FailureValidationBuilder<T, IStringEntryValidationBuilder<T>>(validator, validators, ignore_validators, this);
        }

        public IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> a_value_that_matches(Regex pattern)
        {
            var validator = new RegexValidator<T>(get_null_string_wrapper(), pattern);
            base.add_validator_with_not_wrapper_if_needed(validator);
            return new FailureValidationBuilder<T, IStringEntryValidationBuilder<T>>(validator, validators, ignore_validators, this);
        }

        public IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> a_value_containing(string value)
        {
            var validator = new StringContainsValidator<T>(expression, value);
            base.add_validator_with_not_wrapper_if_needed(validator);
            return new FailureValidationBuilder<T, IStringEntryValidationBuilder<T>>(validator, validators, ignore_validators, this);
        }

        public IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> a_value_containing_at_least_1_capital_letter()
        {
            var validator = new RegexValidator<T>(get_null_string_wrapper(), new Regex(RegexLibrary.at_least_one_capital_letter));
            base.add_validator_with_not_wrapper_if_needed(validator);
            set_regex_validator_failure_message(validator, "a value containing at least 1 capital letter");
            return new FailureValidationBuilder<T, IStringEntryValidationBuilder<T>>(validator, validators, ignore_validators, this);
        }

        public IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> a_value_containing_at_least_1_lowercase_letter()
        {
            var validator = new RegexValidator<T>(get_null_string_wrapper(), new Regex(RegexLibrary.at_least_one_lowercase_letter));
            base.add_validator_with_not_wrapper_if_needed(validator);
            set_regex_validator_failure_message(validator, "a value containing at least 1 lowercase letter");
            return new FailureValidationBuilder<T, IStringEntryValidationBuilder<T>>(validator, validators, ignore_validators, this);
        }

        public IFailureEntryValidationBuilder<T, IStringEntryValidationBuilder<T>> a_value_containing_at_least_1_number()
        {
            var validator = new RegexValidator<T>(get_null_string_wrapper(), new Regex(RegexLibrary.at_least_one_number));
            base.add_validator_with_not_wrapper_if_needed(validator);
            set_regex_validator_failure_message(validator, "a value containing at least 1 number");
            return new FailureValidationBuilder<T, IStringEntryValidationBuilder<T>>(validator, validators, ignore_validators, this);
        }

        void set_regex_validator_failure_message(RegexValidator<T> validator, string ending_value)
        {
            validator.failure_message_strategy =
                new ExpressionFailureMessageStrategy(expression.Body as MemberExpression, String.Empty, ending_value);
        }

        Expression<Func<T, int>> get_length_expression()
        {
            Expression null_wrapper = get_null_coalesce_expression();

            Expression func = Expression.Property(null_wrapper, "Length");
            return Expression.Lambda<Func<T, int>>(func, expression.Parameters);
        }

        BinaryExpression get_null_coalesce_expression()
        {
            Expression<Func<T,string>> empty_string = (x=>String.Empty);
            return Expression.Coalesce(expression.Body, empty_string.Body);
        }

        Expression<Func<T, string>> get_null_string_wrapper()
        {
            Expression null_wrapper = get_null_coalesce_expression();

            var func = Expression.Lambda<Func<T, string>>(null_wrapper, expression.Parameters);
            return func;
        }
    }
}