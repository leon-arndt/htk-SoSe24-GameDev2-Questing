EXTERNAL addQuest(questName)

Slim: There was an accident.

* "What did you see?"
    -> AskWhatSee
* "I don't care"
    -> Cancel


=== AskWhatSee ===
Slim: Two space ships crashed into each other. There was a corrupt business man on that ship. Collect the illegal documents from the briefcase so we can put that thug behind bars. Be careful of the corrupt police drones.

~ addQuest("Documents")

-> END

=== Cancel ===
Slim: Talk to me again when you do care.
-> END
