local debug = {
    print = function(obj)
        print(tostring(obj))
    end
}

require("mod1")

print("Hello World")
print("3 초 뒤 실행")

--[[ Point Struct ]]
local a, b = vector2(1,1), vector2(2,2)
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

local monster = gameObject()

monster.start.add(function()
    print("Hello, World")
end)

game.save()