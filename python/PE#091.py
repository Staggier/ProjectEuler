# problem can be found here: https://projecteuler.net/problem=91

from math import atan2, degrees

class triangle:
    def __init__(self, a: tuple, b: tuple, c: tuple) -> tuple:
        self.a = a
        self.b = b
        self.c = c

    # calculates three different angles needed from three points of this triangle
    def calculate_angles(self, a: tuple, b: tuple, c: tuple) -> tuple:
        return (abs(degrees(atan2(c[1] - b[1], c[0] - b[0]) - atan2(a[1] - b[1], a[0] - b[0]))),
        abs(degrees(atan2(c[1] - b[1], c[0] - b[0]) - atan2(a[1] - c[1], a[0] - c[0]))),
        abs(degrees(atan2(b[1] - c[1], b[0] - c[0]) - atan2(b[1] - a[1], b[0] - a[0]))))

    # determines if the triangle is right angled
    def is_right_angled(self) -> bool:

        # check angles from variation 1
        a = self.calculate_angles(self.a, self.b, self.c)
        if a[0] == 90.0 or a[1] == 90.0 or a[2] == 90.0:
            return True

        # check angles from variation 2
        a = self.calculate_angles(self.b, self.a, self.c)
        if a[0] == 90.0 or a[1] == 90.0 or a[2] == 90.0:
            return True

        # check angles from variation 3
        a = self.calculate_angles(self.c, self.a, self.b)
        if a[0] == 90.0 or a[1] == 90.0 or a[2] == 90.0:
            return True
        
        return False

def num_right_triangles(n: int) -> int:

    # dictionary to keep track of points B and C of a triangle
    d = {}
    c = 0

    for i in range(n + 1):
        for j in range(n + 1):

            # skip when Point B = Point A
            if (i, j) == (0, 0):
                continue

            for k in range(n + 1):
                for l in range(n + 1):

                    # skip when Point B = Point A or Point C
                    if (k, l) == (0, 0) or (k, l) == (i, j):
                        continue

                    t = triangle((0, 0), (i, j), (k, l))

                    # tuples for both variations of a triangle
                    t1 = (t.b, t.c)
                    t2 = (t.c, t.b)

                    # don't want to add identical triangles
                    if (t2 in d):
                        continue

                    if t.is_right_angled():
                        c += 1
                        d[t1] = 1

    return c

print(num_right_triangles(50))
