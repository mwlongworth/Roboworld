function httpGetPlainText(url)
    h = http.get(url,{Accept="text/plain"})
    local content = h.readAll()
    h.close()
    return content
end

function httpGetTable(url)
    h = http.get(url,{Accept="text/plain"})
    local content = h.readAll()
    h.close()
    print("read "..content)
    return load("return "..content)()
end