using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UselessFactApp;

public class ResponseModel
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("source")]
    public string Source { get; set; }

    [JsonPropertyName("source_url")]
    public string SourceUrl { get; set; }

    [JsonPropertyName("language")]
    public string Language { get; set; }

    [JsonPropertyName("permalink")]
    public string Permalink { get; set; }
}
