﻿using System.IO;
using Exceptionless.Serializer;
using MessagePack;

namespace Exceptionless.MessagePack {
    public class MessagePackStorageSerializer : IStorageSerializer {
        private readonly IFormatterResolver _formatterResolver;

        public MessagePackStorageSerializer(IFormatterResolver formatterResolver) {
            _formatterResolver = formatterResolver;
        }

        public void Serialize<T>(T data, Stream output) {
            MessagePackSerializer.Serialize(output, data, _formatterResolver);
        }

        public T Deserialize<T>(Stream input) {
            return MessagePackSerializer.Deserialize<T>(input, _formatterResolver);
        }
    }
}
