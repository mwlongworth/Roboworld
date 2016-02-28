baseUrl = "http://localhost/Roboworld.Gateway.WebApi/software/"

local files = getFilesToUpdate(baseUrl)
print("start")
print(files.length)
for k, v in ipairs(files) do
    local fileUrl = "library/"..v
    print("Downloading update for [" .. v .. "] from ["..fileUrl.."]")
    
    local content = httpGetPlainText(baseUrl..fileUrl)
    saveToDisk("lib/"..v,content)
end
print("done")