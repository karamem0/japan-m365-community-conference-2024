# 徹底解説！Microsoft 365 Copilotの拡張機能

[![license](https://img.shields.io/github/license/karamem0/japan-m365-community-conference-2024.svg)](https://github.com/karamem0/japan-m365-community-conference-2024/blob/main/LICENSE)

[Japan Microsoft 365 コミュニティ カンファレンス 2024](https://japan-m365-community-conference-2024.connpass.com/event/332074/) のセッション A04 で行われる「徹底解説！Microsoft 365 Copilotの拡張機能」のデモ資料です。

## フォルダー構成

- **bicep**: Azure リソースを作成するためのテンプレートを格納します。
- **index**: Azure AI Search のデータ ソース、スキルセット、インデックス、インデクサーの設定情報を格納します。
- **manifest**: Teams アプリのマニフェスト ファイルを格納します。
- **source**: Teams メッセージ拡張機能をホストするボットおよび API プラグインの接続先となる Web API を実装するコードを格納します。
- **sql**: Azure SQL Database のテーブル定義およびデータ定義を格納します。

## アーキテクチャ

```mermaid
flowchart LR
  A[Microsoft 365 Copilot] --> B[Graph コネクタ]
  A[Microsoft 365 Copilot] --> C[コネクタ エージェント]
  C[コネクタ エージェント] --> B[Graph コネクタ]
  B[Graph コネクタ] --> D[SQL Database]
  A[Microsoft 365 Copilot] --> E[API エージェント]
  E[API エージェント] --> F[Azure Web Apps]
  F[Azure Web Apps] --> G[Azure AI Search]
  F[Azure Web Apps] --> H[Azure Storage Account]
  G[Azure AI Search] --> D[SQL Database]
  G[Azure AI Search] --> I[Azure OpenAI Service]
  A[Microsoft 365 Copilot] --> J[プラグイン]
  J[プラグイン] --> K[Azure AI Bot]
  K[Azure AI Bot] --> F[Azure Web Apps]
  subgraph Teams アプリ
    C[コネクタ エージェント]
    E[API エージェント]
    J[プラグイン]
  end
  subgraph Microsoft Search
    B[Graph コネクタ]
  end
  subgraph Microsoft Azure
    D[SQL Database]
    F[Azure Web Apps]
    G[Azure AI Search]
    H[Azure Storage Account]
    I[Azure OpenAI Service]
    K[Azure AI Bot]
  end
```
