euler02 :: Int -> Int -> Int -> Int
euler02 n k max = do if k > max then 0 else do if k `mod` 2 == 0 then k + (euler02 k (n + k) max) else (euler02 k (n + k) max)

main = do
  putStrLn $ show $ euler02 0 1 4000000