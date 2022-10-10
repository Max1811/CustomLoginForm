const PROXY_CONFIG = [
  {
    context: [
      "/api/login",
    ],
    target: "https://localhost:7202",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
