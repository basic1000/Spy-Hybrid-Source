module.exports = {
    log: data => console.log(`[\x1b[31mLOG\x1b[0m] ${data}\x1b[0m`),
    request: data => console.log(`[\x1b[31mPING\x1b[0m] ${data}\x1b[0m`)
}