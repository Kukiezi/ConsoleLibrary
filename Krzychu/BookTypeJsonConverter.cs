using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Krzychu
{
	public class BookTypeJsonConverter : JsonConverter<List<Book>>
	{
        public override List<Book> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
			if (reader.TokenType != JsonTokenType.StartArray)
				throw new JsonException("Expected StartArray token");
			var books = new List<Book>();

			while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
			{
				if (reader.TokenType == JsonTokenType.StartObject)
                {
					var book = new Book();
					while (reader.Read())
                    {
						if (reader.TokenType == JsonTokenType.EndObject)
							break;
						if (reader.TokenType != JsonTokenType.PropertyName)
							throw new JsonException("Expected PropertyName token");

						var propName = reader.GetString();
						reader.Read();
						switch (propName)
						{
							case nameof(Book.Title):
								book.Title = reader.GetString();
								break;
							case nameof(Book.Author):
								book.Author = reader.GetString();
								break;
							case nameof(Book.Type):
								book.Type = BookType.GetBookType(reader.GetString());
								break;
						}
					}
					books.Add(book);
                }
			}
			return books;
		}

        public override void Write(Utf8JsonWriter writer, List<Book> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
