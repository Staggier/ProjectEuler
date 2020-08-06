import Data.List(nub)

euler01 :: Int
euler01 = do
  let lst1 =  [3,6..999]
  let lst2 = [5,10..999]

  sum $ nub $ lst1 ++ lst2
  
main = do
  putStrLn $ show euler01