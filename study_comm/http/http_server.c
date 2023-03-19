#include <stdio.h>
#include <winsock2.h>

int main () {
    WSADATA w;
    struct sockaddr_in server, client;
    char buf[256], sndbuf[256];

    memset(sndbuf, 0, sizeof(sndbuf));
    snprintf(sndbuf, sizeof(sndbuf), 
    "HTTP/1.1 200 OK\r\n"
    "Date: Mon, 13 Jun 2020 9:00:00 GMT\r\n"
    "Server: Apache/2.2\r\n"
    "Content-Length: 13\r\n"
    "\r\n"
    "HELLO CLIENT\r\n");
    
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
        send(sock2, sndbuf, sizeof(sndbuf), 0);
        closesocket(sock2);
    }
    closesocket(sock);


    WSACleanup();

    return 0;
}
