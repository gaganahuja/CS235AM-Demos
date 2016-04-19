﻿using System;
using System.Collections.Generic;
using Android.Runtime;
using System.Xml;
using System.IO;

namespace ListActivitySimpleAdapterXmlFile
{
	public class ReadXmlFile
	{
		List<IDictionary<string,object>> vocabList;

		public List<IDictionary<string, object>> VocabList { get { return vocabList; } }

		public ReadXmlFile (Stream xmlStream)
		{
			// SimleAdapter requires a list of JavaDictionary<string,object> objects
			vocabList = new List<IDictionary<string, object>>(); 
			//for testing
			var item1 = new JavaDictionary<string, object> ();
			item1.Add ("Spanish", "mono");
			item1.Add ("English", "monkey");
			item1.Add ("PartOfSpeech", "noun");
			vocabList.Add(item1);
			var item2 = new JavaDictionary<string, object> ();
			item2.Add ("Spanish", "agua");
			item2.Add ("English", "water");
			item2.Add ("PartOfSpeech", "noun");
			vocabList.Add(item2);
			var item3 = new JavaDictionary<string, object> ();
			item3.Add ("Spanish", "saltar");
			item3.Add ("English", "to jump");
			item3.Add ("PartOfSpeech", "verb");
			vocabList.Add(item3);

			// The real thing
			using (XmlReader reader = XmlReader.Create (xmlStream)) {
				while (reader.Read ()) {
					// Only detect start elements.
					if (reader.IsStartElement ()) {
						// Get element name and switch on it.
						switch (reader.Name) {
						case "vocab":
						// Detect this element.
							Console.WriteLine ("Start <vocab> element.");
							break;
						case "word":
						// Detect this article element.
							Console.WriteLine ("Start <word> element.");
							break;
						case "Spanish":
							// Detect this article element.
							Console.WriteLine ("Start <Spanish> element.");
						// Next read will contain text.
							if (reader.Read ()) {
								Console.WriteLine ("  Text node: " + reader.Value.Trim ());
							}
							break;
						}
					}
				}
			}

		}
	}
}

