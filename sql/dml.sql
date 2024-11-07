--
-- Copyright (c) 2024 karamem0
--
-- This software is released under the MIT License.
--
-- https://github.com/karamem0/japan-m365-community-conference-2024
--

INSERT INTO [dbo].[FaqCategory]
  ([Id], [Name], [Created], [Updated])
VALUES
  (1, N'アカウント管理', N'2000-01-01T00:00:00', N'2000-01-01T00:00:00'),
  (2, N'ソフトウェア', N'2000-01-01T00:00:00', N'2000-01-01T00:00:00'),
  (3, N'ハードウェア', N'2000-01-01T00:00:00', N'2000-01-01T00:00:00'),
  (4, N'ネットワーク', N'2000-01-01T00:00:00', N'2000-01-01T00:00:00'),
  (5, N'セキュリティ', N'2000-01-01T00:00:00', N'2000-01-01T00:00:00'),
  (6, N'その他', N'2000-01-01T00:00:00', N'2000-01-01T00:00:00')
GO

INSERT INTO [dbo].[Faq]
  ([Id], [CategoryId], [Question], [Answer], [Url], [Created], [Updated])
VALUES
  (1, 1, N'パスワードを忘れた場合はどうすればよいですか？', N'パスワードをリセットするには、ログイン画面の「パスワードを忘れた場合」リンクをクリックし、指示に従ってください。', N'https://www.example.com#faq-1', N'2000-01-01T00:00:00', N'2000-01-01T00:00:00'),
  (2, 1, N'アカウントがロックされた場合の対処方法は？', N'アカウントがロックされた場合は、IT ヘルプデスクに連絡してロック解除の手続きを行ってください。', N'https://www.example.com#faq-2', N'2000-01-01T00:00:00', N'2000-01-01T00:00:00'),
  (3, 2, N'新しいソフトウェアをインストールするにはどうすればよいですか？', N'新しいソフトウェアのインストールは、IT ヘルプデスクにリクエストを提出し、承認を得てから行ってください。', N'https://www.example.com#faq-3', N'2000-01-01T00:00:00', N'2000-01-01T00:00:00'),
  (4, 2, N'ソフトウェアのアップデートができない場合の対処方法は？', N'ソフトウェアのアップデートができない場合は、インターネット接続を確認し、再試行してください。それでも解決しない場合は、IT ヘルプデスクに連絡してください。', N'https://www.example.com#faq-4', N'2000-01-01T00:00:00', N'2000-01-01T00:00:00'),
  (5, 3, N'プリンターが動作しない場合の対処方法は？', N'プリンターが動作しない場合は、電源と接続を確認し、再起動してください。それでも解決しない場合は、IT ヘルプデスクに連絡してください。', N'https://www.example.com#faq-5', N'2000-01-01T00:00:00', N'2000-01-01T00:00:00'),
  (6, 3, N'新しいハードウェアを接続するにはどうすればよいですか？', N'新しいハードウェアの接続は、IT ヘルプデスクにリクエストを提出し、承認を得てから行ってください。', N'https://www.example.com#faq-6', N'2000-01-01T00:00:00', N'2000-01-01T00:00:00'),
  (7, 4, N'Wi-Fi に接続できない場合の対処方法は？', N'Wi-Fi に接続できない場合は、ルーターを再起動し、接続設定を確認してください。それでも解決しない場合は、IT ヘルプデスクに連絡してください。', N'https://www.example.com#faq-7', N'2000-01-01T00:00:00', N'2000-01-01T00:00:00'),
  (8, 4, N'VPN に接続する方法は？', N'VPN に接続するには、提供された VPN クライアント ソフトウェアをインストールし、指示に従って設定を行ってください。', N'https://www.example.com#faq-8', N'2000-01-01T00:00:00', N'2000-01-01T00:00:00'),
  (9, 5, N'フィッシング メールを受け取った場合の対処方法は？', N'フィッシング メールを受け取った場合は、リンクをクリックせず、IT ヘルプデスクに報告してください。', N'https://www.example.com#faq-9', N'2000-01-01T00:00:00', N'2000-01-01T00:00:00'),
  (10, 5, N'ウイルスに感染した場合の対処方法は？', N'ウイルスに感染した場合は、ネットワークから切断し、IT ヘルプデスクに連絡して指示を仰いでください。', N'https://www.example.com#faq-10', N'2000-01-01T00:00:00', N'2000-01-01T00:00:00')
GO
