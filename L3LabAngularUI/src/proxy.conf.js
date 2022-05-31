const PROXY_CONFIG = [
  {
    context: [
      "/api/Notes",
    ],
    target: "https://localhost:4171",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
