IEvaluator[] evaluators = [
        // 関連性、真実性、完全性を評価するための評価器
        new RelevanceTruthAndCompletenessEvaluator(),
        // 流暢さを評価するための評価器
        new FluencyEvaluator(),
        // 類似性を評価するための評価器
        new EquivalenceEvaluator(),
    ];

var chatClient = new AzureOpenAIClient(
    // AOAI のエンドポイント
    new("https://<<AOAI のリソース名>>.openai.azure.com/"),
    // AOAI に接続するための資格情報 (キーで接続する場合は AzureKeyCredential を使う)
    new AzureCliCredential())
    // gpt-4o という名前でデプロイされた gpt-4o モデルを使うチャットクライアントを作成
    .AsChatClient("gpt-4o");
// gpt-4o 用の Tokenizer を作成
var tokenizer = TiktokenTokenizer.CreateForModel("gpt-4o");
// チャット設定を作成 (入力トークン数の上限を 6000 に設定)
var chatConfig = new ChatConfiguration(chatClient, tokenizer.ToTokenCounter(inputTokenLimit: 6000));
