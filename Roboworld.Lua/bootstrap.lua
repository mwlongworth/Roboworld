print("Bootstrapper version 1")


f=fs.open("bootstrap","w")
h=http.get("http://localhost/Roboworld.Gateway.WebApi/software/bootstrap",{Accept="text/plain"})
f.write(h.readAll()) 
f.close()
h.close()
print("Update complete!")