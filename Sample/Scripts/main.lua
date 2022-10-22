local debug = {
    print = function(obj)
        print(tostring(obj))
    end
}
print("Start Window")
wait()

--[[ Point Struct ]]
local a, b = point(1,1), point(2,2)
debug.print(a + b)
debug.print(a - b)
debug.print(a * b)
debug.print(a / b)
debug.print(a == b)
--]]

--[[ Color Struct ]]
print(color.black.r)
print(color.black.g)
print(color.black.b)
print(color.black.a)