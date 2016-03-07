os.loadAPI("lib/web")
os.loadAPI("lib/gateway")
print("Robot main loop V0.1")

local listening = true
while listening do
    print(gateway.getCommand())
    os.sleep(1)
end