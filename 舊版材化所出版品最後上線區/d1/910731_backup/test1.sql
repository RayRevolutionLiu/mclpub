  SELECT c1_order.o_otp2cd,   
         c1_order.o_otp1cd,   
         c1_od.od_btpcd,   
         sum(c1_od.od_amt ),   
         sum(c1_ramt.ra_mnt)  
    FROM c1_order,   
         c1_od,   
         c1_ramt  
   WHERE ( c1_order.o_syscd = c1_od.od_syscd ) and  
         ( c1_order.o_custno = c1_od.od_custno ) and  
         ( c1_order.o_otp1cd = c1_od.od_otp1cd ) and  
         ( c1_order.o_otp1seq = c1_od.od_otp1seq ) and  
         ( c1_od.od_syscd = c1_ramt.ra_syscd ) and  
         ( c1_od.od_custno = c1_ramt.ra_custno ) and  
         ( c1_od.od_otp1cd = c1_ramt.ra_otp1cd ) and  
         ( c1_od.od_otp1seq = c1_ramt.ra_otp1seq ) and  
         ( c1_od.od_oditem = c1_ramt.ra_oditem )   
GROUP BY c1_order.o_otp1cd,   
         c1_order.o_otp2cd,   
         c1_od.od_btpcd  
ORDER BY c1_order.o_otp1cd ASC,   
         c1_order.o_otp2cd ASC,   
         c1_od.od_btpcd ASC   

