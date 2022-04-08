# kujiro-xss-frontend

2022/04/08 に行われた「誰ですか こんなところにXSS仕掛けたのは」(kujiro) の C# 製フロントエンドです。

[バックエンドはこちら](https://github.com/HUITGroup/kujiro-xss-backend)

docker compose を使用して構築します。

## 事前準備

1. SSLの証明書(ssl.crt)と秘密鍵(ssl.crt)をディレクトリ内に置く
1. [nginx.conf](nginx.conf) の server_name を公開したいドメインに修正する
1. [Setting.cs](HUIT2022/Pages/Setting.cs) の HostAddr をAPIのドメインに修正する

## 構築

```bash
docker compose up -d
```
