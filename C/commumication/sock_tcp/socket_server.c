#include <stdio.h>
#include <winsock2.h>

int main () {
    WSADATA w;
    struct sockaddr_in server, client;
    char buf[256];
    
    WSAStartup(MAKEWORD(2,0), &w);
    int sock = socket(AF_INET, SOCK_STREAM, 0);
    server.sin_addr.s_addr = INADDR_ANY;
    server.sin_port = htons(9999);
    server.sin_family = AF_INET;

    bind(sock, (struct sockaddr *)&server, sizeof(server));
    listen(sock, 1);

    for (;;) {
        int len = sizeof(client);
        int sock2 = accept(sock, (struct sockaddr *)&client, &len);

        recv(sock2, buf, sizeof(buf), 0);
        printf("%s\n", buf);
        closesocket(sock2);
    }
    closesocket(sock);

    WSACleanup();

    return 0;
}

//memo ライブラリ使うからコンパイルオプションがいる。
// gcc -lwsock32 '.\socket_server.c' -lws2_32 -o server
