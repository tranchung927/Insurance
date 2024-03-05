using InsuranceCore.Specifications.FilterSpecifications;
using InsuranceCore.Specifications.FilterSpecifications.Filters;
using System;
using System.Collections.Generic;

namespace InsuranceCore.Models.Builders.Specifications.Post
{
    /// <summary>
    /// Class used to generate <see cref="FilterSpecification{TEntity}"/> for <see cref="Post"/>.
    /// </summary>
    public class PostFilterSpecificationBuilder
    {

        private string _inName;
        private string _inContent;
        private DateTimeOffset? _toPublishedAt;
        private DateTimeOffset? _fromPublishedAt;
        private List<string> _tags;

        public PostFilterSpecificationBuilder WithInContent(string inContent)
        {
            _inContent = inContent;
            return this;
        }

        public PostFilterSpecificationBuilder WithInName(string inName)
        {
            _inName = inName;
            return this;
        }

        public PostFilterSpecificationBuilder WithToPublishedAt(DateTimeOffset? toPublishedAt)
        {
            _toPublishedAt = toPublishedAt;
            return this;
        }

        public PostFilterSpecificationBuilder WithFromPublishedAt(DateTimeOffset? fromPublishedAt)
        {
            _fromPublishedAt = fromPublishedAt;
            return this;
        }

        public PostFilterSpecificationBuilder WithTags(List<string> tags)
        {
            _tags = tags;
            return this;
        }

        /// <summary>
        /// Get filter specification of <see cref="Post"/> based of internal properties defined.
        /// </summary>
        /// <returns></returns>
        public FilterSpecification<Data.Post> Build()
        {

            FilterSpecification<Data.Post> filter = null;

            if (_inContent != null)
                filter = new ContentContainsSpecification<Data.Post>(_inContent);
            if (_inName != null)
            {
                filter = filter == null ?
                    new NameContainsSpecification<Data.Post>(_inName)
                    : filter & new NameContainsSpecification<Data.Post>(_inName);
            }
            if (_toPublishedAt != null)
            {
                filter = filter == null ?
                    new PublishedBeforeDateSpecification<Data.Post>(_toPublishedAt.Value)
                    : filter & new PublishedBeforeDateSpecification<Data.Post>(_toPublishedAt.Value);
            }
            if (_fromPublishedAt != null)
            {
                filter = filter == null ?
                    new PublishedAfterDateSpecification<Data.Post>(_fromPublishedAt.Value)
                    : filter & new PublishedAfterDateSpecification<Data.Post>(_fromPublishedAt.Value);
            }
            if (_tags != null)
            {
                foreach (var tag in _tags)
                {
                    filter = filter == null
                        ? new TagSpecification<Data.Post>(tag)
                        : filter & new TagSpecification<Data.Post>(tag);
                }
            }

            return filter;
        }
    }
}
