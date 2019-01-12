const Agent = require('agentkeepalive');
var httpProxy = require('http-proxy');

module.exports = {
    '/api' : {
        target: 'http://localhost:52775',
        changeOrigin: true,
        agent: new Agent({
            maxSockets: 100,
            keepAlive: true,
            maxFreeSockets: 10,
            keepAliveMsecs: 100000,
            timeout: 6000000,
            keepAliveTimeOut: 90000
        }),
        onProxyRes: proxyRes => {
            var key = 'www-authenticate';
            proxyRes.headers[key] = proxyRes.headers[key] && proxyRes.headers[key].split(',');
        }
    }
}