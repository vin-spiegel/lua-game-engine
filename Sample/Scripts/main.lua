local debug = {
    print = function(obj)
        print(tostring(obj))
    end
}

print("Hello World")
print("3 초 뒤 실행")


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
print(color.black[1])

print(typeof(point))
print(typeof(a))

print(deltaTime)

print(entity)
local monster = entity()
print(#window.entities)