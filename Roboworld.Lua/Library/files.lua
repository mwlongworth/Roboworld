function saveToDisk(filename, content)
    f = fs.open(filename, "w")
    f.write(content)
    f.close()
end