<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:output omit-xml-declaration="yes" indent="yes"/>
  <xsl:strip-space elements="*"/>


  <xsl:template match="/">
    <table>
      <xsl:apply-templates/>
    </table>
  </xsl:template>

  <xsl:template match="*">
    <tr>
      <td style="background-color: #bbb;">
        <p>
          <xsl:value-of select="name()"/>
        </p>
      </td>
      <td style="background-color: #bbb;">
        <p>
          <xsl:value-of select="."/>
        </p>
      </td>
    </tr>
  </xsl:template>

  <xsl:template match="*[*]">
    <tr>
      <td style="border:2px solid #bbb; font-size:120%;">
        <p>
          <xsl:value-of select="name()"/>
          <p>
          <xsl:value-of select="name(@*)"/>
          <xsl:value-of select="@*"/>
          </p>
        </p>
      </td>
      <td style="">
        <table>
          <xsl:apply-templates/>
        </table>
      </td>
    </tr>
  </xsl:template>

</xsl:stylesheet>
