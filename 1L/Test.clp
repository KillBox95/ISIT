
;;;======================================================
;;;   Automotive Expert System
;;;
;;;     This expert system diagnoses some simple
;;;     problems with a car.
;;;
;;;     CLIPS Version 6.3 Example
;;;
;;;     To execute, merely load, reset and run.
;;;======================================================

;;****************
;;* DEFFUNCTIONS *
;;****************

(deffunction ask-question (?question $?allowed-values)
   (printout t ?question)
   (bind ?answer (read))
   (if (lexemep ?answer) 
       then (bind ?answer (lowcase ?answer)))
   (while (not (member ?answer ?allowed-values)) do
      (printout t ?question)
      (bind ?answer (read))
      (if (lexemep ?answer) 
          then (bind ?answer (lowcase ?answer))))
   ?answer)

(deffunction yes-or-no-p (?question)
   (bind ?response (ask-question ?question yes no y n))
   (if (or (eq ?response yes) (eq ?response y))
       then yes 
       else no))

;;;***************
;;;* QUERY RULES *
;;;***************

(defrule choosing_the_type_of_shoes ""
   (not (need-sneakers ?))
   (not (repair ?))
   =>
   (assert (need-sneakers (yes-or-no-p "do you need sneakers? (yes/no)? "))))

(defrule choosing_shoes_by_price ""
   (not (budget ?))
   (not (repair ?))
   =>
   (assert (budget (ask-question "your budget? (<5000/>5000)? " <5000 >5000))))

 (defrule choosing_shoes_winter ""
   (not (winer ?))
   (not (repair ?))
   =>
   (assert (winer (yes-or-no-p "will you wear it in winter? (yes/no)? "))))
   
(defrule choosing_shoes_summer ""
   (not (summer ?))
   (not (repair ?))
   =>
   (assert (summer (yes-or-no-p "will you wear it in summer? (yes/no)? ")))) 

(defrule choosing_shoes_namber_shoes ""
   (not (namber-shoes ?))
   (not (repair ?))
   =>
   (assert (namber-shoes (ask-question "how many shoes? (yes/no)? " <10 >10))))

(defrule workload_level_hard ""
   (not (level-work ?))
   (not (winer yes))
   (not (summer yes))
   (not (repair ?))
   =>
   (assert (level-work (hard)))
   
 (defrule workload_level_easy_1 ""
   (not (level-work ?))
   (not (winer no))
   (not (summer no))
   (not (repair ?))
   =>
   (assert (level-work (easy)))
   
 (defrule workload_level_easy_2 ""
   (not (level-work ?))
   (not (winer yes))
   (not (summer no))
   (not (repair ?))
   =>
   (assert (level-work (easy)))
   
  (defrule workload_level_easy_3 ""
   (not (level-work ?))
   (not (winer no))
   (not (summer yes))
   (not (repair ?))
   =>
   (assert (level-work (easy)))
   
  (defrule load_type_sports ""
   (not (type ?))
   (not (level-work hard))
   (not (need-sneakers yes))
   (not (repair ?))
   =>
   (assert (type (sports)))
   
 (defrule load_type_norm ""
   (not (type ?))
   (not (level-work easy))
   (not (need-sneakers no))
   (not (repair ?))
   =>
   (assert (type (norm)))
   
(defrule level ""
   (not (level ?))
   (not (namber-shoes >10))
   (not (repair ?))
   =>
   (assert (level (expert)))
   
 (defrule level_noob ""
   (not (level ?))
   (defrule workload_level_hard ""
   (not (level-work ?))
   (not (winer yes))
   (not (summer yes))
   (not (repair ?))
   =>
   (assert (level-work (hard)))
   
 (defrule workload_level_easy_1 ""
   (not (level-work ?))
   (not (winer no))
   (not (summer no))
   (not (repair ?))
   =>
   (assert (level-work (easy)))
   
 (defrule workload_level_easy_2 ""
   (not (level-work ?))
   (not (winer yes))
   (not (summer no))
   (not (repair ?))
   =>
   (assert (level-work (easy)))
   
  (defrule workload_level_easy_3 ""
   (not (level-work ?))
   (not (winer no))
   (not (summer yes))
   (not (repair ?))
   =>
   (assert (level-work (easy)))
   
  (defrule load_type_sports ""
   (not (type ?))
   (not (level-work hard))
   (not (need-sneakers yes))
   (not (repair ?))
   =>
   (assert (type (sports)))
   
 (defrule load_type_norm ""
   (not (type ?))
   (not (level-work easy))
   (not (need-sneakers no))
   (not (repair ?))
   =>
   (assert (type (norm)))
   
(defrule level_expert ""
   (not (level ?))
   (not (namber-shoes >10))
   (not (repair ?))
   =>
   (assert (level (expert)))
      
 (defrule level_noob ""
   (not (level ?))
   (not (namber-shoes <10))
   (not (repair ?))
   =>
   (assert (level (noob)))

;;;****************
;;;* REPAIR RULES *
;;;****************

(defrule result_patrol_boots ""
   (type norm)
   (budget <5000)
   (not (repair ?))
   =>
   (assert (repair "You should buy Patrol Boots (3000R)")))
   
 (defrule result_roberto_botticelli ""
   (type norm)
   (budget >5000)
   (level expert)
   (not (repair ?))
   =>
   (assert (repair "You should buy ROBERTO BOTTICELLI (30 000Р)")))
   
 (defrule result_demix_fluid_plus ""
   (type sports)
   (budget <5000)
   (level noob)
   (not (repair ?))
   =>
   (assert (repair "You should buy Demix Fluid Plus (3 000Р)")))
   
 (defrule result_hoka_one_bondi ""
   (type sports)
   (budget >5000)
   (not (repair ?))
   =>
   (assert (repair "You should buy HOKA ONE Bondi X (27 000Р)")))
 
 (defrule result_timberland ""
   (type sports)
   (level expert)
   (winer yes)
   (budget >5000)
   (not (repair ?))
   =>
   (assert (repair "You should buy TIMBERLAND ICONS(25 000R)")))
   
 (defrule result_adidas_yeezy ""
   (level expert)
   (budget >5000)
   (not (repair ?))
   =>
   (assert (repair "You should buy Adidas Yeezy Boost 350 (15 000R)")))
   
 (defrule result_nike_monarch ""
   (level noob)
   (budget <5000)
   (not (repair ?))
   =>
   (assert (repair "You should buy Nike Air Monarch IV (4 000R)"))) 


;;;********************************
;;;* STARTUP AND CONCLUSION RULES *
;;;********************************

(defrule system-banner ""
  (declare (salience 10))
  =>
  (printout t crlf crlf)
  (printout t "The Engine Diagnosis Expert System")
  (printout t crlf crlf))

(defrule print-repair ""
  (declare (salience 10))
  (repair ?item)
  =>
  (printout t crlf crlf)
  (printout t "Suggested Repair:")
  (printout t crlf crlf)
  (format t " %s%n%n%n" ?item))

