using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.FilterSpecifications.Filters;
using System;

namespace InsuranceCore.Models.Builders.Specifications.User
{
    /// <summary>
    /// Class used to generate <see cref="FilterSpecification{TEntity}"/> for <see cref="User"/>.
    /// </summary>
    public class UserFilterSpecificationBuilder
    {
        private string _inUserName;
        private DateTimeOffset? _fromRegister;
        private DateTimeOffset? _toRegister;
        private DateTimeOffset? _fromLastLogin;
        private DateTimeOffset? _toLastLogin;

        public UserFilterSpecificationBuilder WithInUserName(string inUserName)
        {
            _inUserName = inUserName;
            return this;
        }

        public UserFilterSpecificationBuilder WithFromRegister(DateTimeOffset? fromRegister)
        {
            _fromRegister = fromRegister;
            return this;
        }

        public UserFilterSpecificationBuilder WithToRegister(DateTimeOffset? toRegister)
        {
            _toRegister = toRegister;
            return this;
        }

        public UserFilterSpecificationBuilder WithFromLastLogin(DateTimeOffset? fromLastLogin)
        {
            _fromLastLogin = fromLastLogin;
            return this;
        }

        public UserFilterSpecificationBuilder WithToLastLogin(DateTimeOffset? toLastLogin)
        {
            _toLastLogin = toLastLogin;
            return this;
        }

        /// <summary>
        /// Get filter specification of <see cref="User"/> based of internal properties defined.
        /// </summary>
        /// <returns></returns>
        public FilterSpecification<Data.User> Build()
        {

            FilterSpecification<Data.User> filter = null;

            if (_fromLastLogin != null)
                filter = new LastLoginBeforeDateSpecification<Data.User>(_fromLastLogin.Value);
            if (_fromRegister!= null)
            {
                filter = filter == null ?
                    new RegisterBeforeDateSpecification<Data.User>(_fromRegister.Value) 
                    : filter & new RegisterBeforeDateSpecification<Data.User>(_fromRegister.Value);
            }
            if (_toLastLogin != null)
            {
                filter = filter == null
                    ? new LastLoginAfterDateSpecification<Data.User>(_toLastLogin.Value)
                    : filter & new LastLoginAfterDateSpecification<Data.User>(_toLastLogin.Value);
            }
            if (_toRegister != null)
            {
                filter = filter == null
                    ? new RegisterAfterDateSpecification<Data.User>(_toRegister.Value)
                    : filter & new RegisterAfterDateSpecification<Data.User>(_toRegister.Value);
            }
            if (_inUserName != null)
            {
                filter = filter == null ?
                    new UsernameContainsSpecification<Data.User>(_inUserName)
                    : filter & new UsernameContainsSpecification<Data.User>(_inUserName);
            }

            return filter;
        }
    }
}
