function getText(url)
    h = http.get(url,{Accept="text/plain"})
    local content = h.readAll()
    h.close()
    return content
end

function getTable(url)
    h = http.get(url,{Accept="text/plain"})
    local content = h.readAll()
    h.close()
    return load("return "..content)()
end