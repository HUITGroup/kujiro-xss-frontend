# kujiro-xss-frontend

2022/04/08 に行われたXSS体験の C# 製フロントエンドです。

docker compose を使用して構築します。

## 事前準備

SSLの証明書(ssl.crt)と秘密鍵(ssl.crt)をディレクトリ内に置いてください。

docker compose で自動的にマウントされます。

## 構築

```bash
docker compose up -d
```
